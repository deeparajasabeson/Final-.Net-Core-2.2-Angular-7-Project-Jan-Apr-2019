import { Component, OnInit } from '@angular/core';
import { Product } from '../Models/Product';
import { StoreService } from '../services/storeService';
import { CartService } from '../services/cartService';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styles: []
})
export class StoreComponent implements OnInit {

  products: Product[];
  constructor(private storeService: StoreService, public cartService: CartService) { }

  ngOnInit() {
    this.storeService.getProducts().subscribe((res) => {
      this.products = res;
    })
  }

}
