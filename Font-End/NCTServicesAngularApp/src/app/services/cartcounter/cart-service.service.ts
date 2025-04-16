import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {
  private cartCount = new BehaviorSubject<number>(0); // Khởi tạo BehaviorSubject với giá trị ban đầu là 0
  cartCount$ = this.cartCount.asObservable(); // Observable để các component khác theo dõi
  
  constructor() { }
  
  addToCart() {
    const currentCount = this.cartCount.value;
    this.cartCount.next(currentCount + 1); // Tăng giá trị lên 1
  }
}
