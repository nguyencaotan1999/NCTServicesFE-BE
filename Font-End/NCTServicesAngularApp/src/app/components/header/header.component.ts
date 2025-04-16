import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { CartServiceService } from '../../services/cartcounter/cart-service.service';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit   {
  cookieValue: string = '';
  public CartCounter: number = 0 ;
  Array: any = [];
  objecta: object = {};
  constructor(private cookieService: CookieService, private cartService: CartServiceService) { 

  }
  ngOnInit(): void {
    this.cartService.cartCount$.subscribe(count => {
      this.CartCounter = count;
    });
    this.cookieValue = this.cookieService.get('myCookie');
    console.log(this.cookieValue);
  }

  AddProdtoCart() { 
    console.log(this.CartCounter);
    this.CartCounter += 1;
    console.log(this.CartCounter);
  }

  RemoveProdtoCart() { 
    if (this.CartCounter > 0) { 
      this.CartCounter--;
    }
  }

  setCookie() {
   this.objecta = {
     name: "abc",
     age: 178,
     sdt:123
    };
    const objectvalue = this.objecta;

    this.Array.push(objectvalue);
    console.log(this.Array[0]);
    // Thiết lập cookie với tên 'myCookie', giá trị 'Hello Angular', hết hạn sau 7 ngày
    const jsonObject = JSON.stringify(this.Array[0]);
    this.cookieService.set('myCookie', jsonObject, 7);
    this.cookieValue = this.cookieService.get('myCookie');
  }
  getCookie() {
    // Lấy giá trị cookie
    this.cookieValue = this.cookieService.get('myCookie');

  }

  deleteCookie() {
    // Xóa cookie
    this.cookieService.delete('myCookie');
    this.cookieValue = '';
  }
}
