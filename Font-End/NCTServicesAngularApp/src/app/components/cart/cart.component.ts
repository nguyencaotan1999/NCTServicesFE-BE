import { ChangeDetectorRef, Component, OnInit,ViewChildren,QueryList,AfterViewInit,ElementRef,Directive } from '@angular/core';
import { DataServices } from '../Common/Common.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,HttpClientModule,FormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
  
export class CartComponent implements OnInit, AfterViewInit {
  @ViewChildren('tableCart') ListCartData!: QueryList<ElementRef>;
  @ViewChildren('PopUpDelete') popUpDelete!: ElementRef;

  ArrayListCart: any[] = [];
  ArrayListCartChange: any[] = [];
  feeShipping: number = 45000;
  Total: number = 0;
  subtotal: number = 0;
  DeleteorderDetailName: string = '';
  OrderDetailId: number = 0;

  constructor(private dataServices: DataServices, private cdr: ChangeDetectorRef) { 
    
  }
  ngOnInit(): void {
    this.renderCart();
    
  }
  ngAfterViewInit(): void {
   
  }

  SubmitCart() { 
    const UrlAPI = 'https://localhost:7071/api/v1/UpdateOrderDetail';
    this.dataServices.postData(UrlAPI, this.ArrayListCart).subscribe(
      (data: any) => {
        if (data) {
          this.renderCart();

        } else { 
          alert("Cập Nhật Thất Bại");

        }
      },
      (error) => {
        alert("Cập Nhật Thất Bại");

    }
    );
  }


  changeValueInTable(event: any, product: any, index: number) {
    const newValue = event.target.value;
    const updatedProduct = { ...product, quantity: newValue };
    this.ArrayListCart[index] = updatedProduct;
    this.calculateTotalPrice(this.ArrayListCart);
    this.ArrayListCartChange.push(updatedProduct);
  }

  DeleteOrderDetailFunction(event: any, product: any) { 
    this.DeleteorderDetailName = product.productName;
    this.OrderDetailId = product.orderDetailId;
  }


  SubmitDelete() { 

    if (this.OrderDetailId != 0) { 
      const UrlAPI = 'https://localhost:7071/api/v1/OrderDetail?OrderDetailId=' + this.OrderDetailId;
    this.dataServices.deleteData(UrlAPI).subscribe(
      (data: boolean) => {
        if (data) {
          this.renderCart();

        } else { 
          alert("Xóa Thất Bại");


        }
      },
      (error) => {
        alert("Xóa Thất Bại");

    }
    );
    }

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
    this.subtotal = totals;
    this.Total = this.subtotal + this.feeShipping;
  }


  renderCart() { 
    
    const apiUrl = 'https://localhost:7071/api/v1/Order?id=2';

    this.dataServices.getData(`${apiUrl}`).subscribe(
        (data: any[]) => {
        this.ArrayListCart = data;
        this.calculateTotalPrice(this.ArrayListCart);
        this.cdr.detectChanges(); 
        },
        (error) => {
      }
      );
  }
}
