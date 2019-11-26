import { Component } from '@angular/core';
import { CartService } from './services/cartService';
import { Cart } from './Models/Cart';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  cart: Cart;
  constructor(private cartService: CartService) {
    this.cart = cartService.getCart();
  }
}
