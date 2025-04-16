import { Component, OnInit } from '@angular/core';
import { DataServices } from '../Common/Common.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [DataServices,CommonModule,FormsModule],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.css'
})
export class CheckoutComponent implements OnInit {
  ProductList: any;
  Calculate: number = 0;
  total: number = 0;
  FeeShipping: number = 45000;

  constructor(private dataServices: DataServices) {}

  ngOnInit(): void {
    this.RenderCheckoutTable();
  }

  calculateTotalPrice(data: any[]): void { 
    let totals = 0;
    let quantity = 0;
    let price = 0;
    for (let i = 0; i < data.length; i++) {
      quantity = data[i].quantity;
      price = data[i].productPrice;
      totals += price * quantity;
    }
    this.Calculate = totals;
    console.log(this.Calculate);
    this.total = totals + this.FeeShipping;
    console.log(this.total);
  }

  RenderCheckoutTable() { 
    const UrlApi = 'https://localhost:7071/api/v1/Checkout?id=2';
    this.dataServices.getData(`${UrlApi}`).subscribe(
      (data: any[]) => {
        this.ProductList = data;
        this.calculateTotalPrice(this.ProductList);
        
        },
        (error) => {
      }
    );
  }
}
