import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cartService';
import { Cart } from '../Models/Cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styles: []
})
export class CartComponent implements OnInit {
  cart: Cart;
  constructor(public cartService: CartService) {
    this.cart = cartService.getCart();
  }

  ngOnInit() {
  }

  checkout() {
  }

}
