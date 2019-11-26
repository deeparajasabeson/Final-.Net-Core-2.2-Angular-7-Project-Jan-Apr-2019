import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/Product';
import { environment as env} from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class StoreService {
  httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient) {
    this.httpHeaders = new HttpHeaders({ 'content-type': 'application/json' });
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(env.apiAddress + '/store/getproducts');
  }

  addCart(cart: any): Observable<any> {
    return this.httpClient.post<any>(env.apiAddress + '/store/savecart', JSON.stringify(cart), {headers: this.httpHeaders });
  }
}
