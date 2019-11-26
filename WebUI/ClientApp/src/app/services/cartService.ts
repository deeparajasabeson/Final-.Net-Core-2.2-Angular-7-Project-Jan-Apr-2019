import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import { Cart } from '../Models/Cart';
import { CartItem } from '../Models/CartItem';

declare const $: any;
declare const CryptoJS: any;
declare const localStorage: any;

@Injectable()
export class CartService {
  private cart: Cart;
  constructor() {
    this.cart = new Cart();
  }

  saveCart() {
    if (localStorage != null) {
      var data = JSON.stringify(this.cart.Items);
      var encData = CryptoJS.AES.encrypt(data, env.encKey);
      localStorage[this.cart.CartName] = encData;
    }
  }

  getCart() {
    if (localStorage != null && localStorage[this.cart.CartName] != undefined && localStorage[this.cart.CartName] != "") {
      var encData = localStorage[this.cart.CartName];
      var bytes = CryptoJS.AES.decrypt(encData.toString(), env.encKey);
      var data = bytes.toString(CryptoJS.enc.Utf8);

      this.cart.Items = JSON.parse(data);
      this.calculateCart();
    }
    return this.cart;
  }

  clearCart() {
    this.cart.Items = [];
    this.cart.Total = 0;
    if (localStorage != null) {
      localStorage[this.cart.CartName] = '';
    }
    this.cart.TotalItems = 0;
  }

  calculateCart() {
    let count = 0;
    let price = 0;
    for (let i = 0; i < this.cart.Items.length; i++) {
      const item = this.cart.Items[i];
      count += item.Quantity;
      price += this.cart.Items[i].Total = item.Quantity * item.UnitPrice;
    }
    this.cart.TotalItems = count;
    this.cart.Total = price;
  }

  addToCart(ProductId: number, Name: string, UnitPrice: number, Quantity: number) {
    console.log(ProductId, Name, UnitPrice, Quantity);
    if (Quantity != undefined) {
      let found = false;
      for (let i = 0; i < this.cart.Items.length && !found; i++) {
        const item: CartItem = this.cart.Items[i];
        if (item.ProductId === ProductId) {
          found = true;
          item.Quantity += Quantity;
        }
      }
      if (!found) {
        const item = new CartItem(ProductId, Name, UnitPrice, Quantity);
        this.cart.Items.push(item);
      }
      this.calculateCart();
      this.saveCart(); // save to localStorage
    }
  }

  deleteFromCart(ProductId: number) {
    for (let i = 0; i < this.cart.Items.length; i++) {
      const item = this.cart.Items[i];
      if (item.ProductId === ProductId) {
        this.cart.Items.splice(i, 1);
      }
    }
    this.calculateCart();
    this.saveCart();
  }

  checkoutPayUmoney(user: any) {
    const params = {
      url: env.paymentGatewayUrl,
      options: {
        key: env.paymentGatewayKey,
        salt: env.paymentGatewaySalt,
        txnid: (Math.random() * 10000000000).toFixed(0), //with 10 numbers
        amount: this.cart.Total,
        productinfo: this.cart.CartName + '_' + this.cart.Total,
        firstname: user.name,
        email: user.username,
        phone: user.contactNo,
        surl: env.baseAddress + '/home/PaymentStatus',
        furl: env.baseAddress + '/home/PaymentStatus',
        service_provider: '',
        hash: '',
        udf1: this.cart.CartId,
        udf2: user.userId
      }
    };

    const str =
      params.options.key + '|' +
      params.options.txnid + '|' +
      params.options.amount + '|' +
      params.options.productinfo + '|' +
      params.options.firstname + '|' +
      params.options.email + '|' +
      params.options.udf1 + '|' +
      params.options.udf2 + '|||||||||' +
      params.options.salt;
    //console.log(str);

    params.options.hash = CryptoJS.SHA512(str).toString();
    //console.log(params.options.hash);
    //build form
    const form = $('<form></form>');
    form.attr('action', params.url);
    form.attr('method', 'POST');
    form.attr('style', 'display:none;');
    this.addFormFields(form, params.options);
    $('body').append(form);

    this.clearCart();
    form.submit();
    form.remove();
  }

  //adding hidden fields to form
  addFormFields(form: any, data: any) {
    if (data != null) {
      $.each(data, function (Name: string, value: string) {
        if (value != null) {
          const input = $('<input></input>').attr('type', 'hidden').attr('Name', Name).val(value);
          form.append(input);
        }
      });
    }
  }
}
