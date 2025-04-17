import { ChangeDetectorRef, Component, OnInit,ViewChildren,QueryList,AfterViewInit,ElementRef,Renderer2 } from '@angular/core';
import { DataServices } from '../Common/Common.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastMessageComponent } from '../../services/toast/toast-message/toast-message.component';



@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
  providers: [ToastMessageComponent]
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
  IsLoading: boolean = false;

  constructor(private dataServices: DataServices, private cdr: ChangeDetectorRef,private toast:ToastMessageComponent ) { 
    
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
          // this.Message = 'Cập Nhật Thành Công';
          this.toast.showSuccess('Cập Nhật Thành Công');
         
        } else { 
          // this.Message = 'Cập Nhật Thất Bại';
          this.toast.showError('Cập Nhật Thất Bại');
        }
      },
      (error) => {
        // this.Message = 'Cập Nhật Thất Bại';
        this.toast.showError('Cập Nhật Thất Bại');
    }
    );
  }


  changeValueInTable(event: any, product: any, index: number) {
    const newValue = event.target.value;
    const updatedProduct = { ...product, quantity: newValue };
    this.ArrayListCart[index] = updatedProduct;
    this.calculateTotalPrice(this.ArrayListCart);
    this.ArrayListCartChange = this.ArrayListCart;
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
          //  this.Message = 'Xóa Cập Nhật';
          this.toast.showSuccess('Xóa thành công');
        } else { 
          // this.Message = 'Xóa Thất Bại';
          this.toast.showError('Xóa Thất Bại');
        }
      },
      (error) => {
        // this.Message = 'Xóa Thất Bại';
        this.toast.showError('Xóa Thất Bại');
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
    this.IsLoading = true;
    const apiUrl = 'https://localhost:7071/api/v1/Order?id=2';

    this.dataServices.getData(`${apiUrl}`).subscribe(
      (data: any[]) => {
          this.ArrayListCart = data;
          this.calculateTotalPrice(this.ArrayListCart);
          this.cdr.detectChanges(); 
          this.IsLoading = false;
        },
        (error) => {
      }
    );
  }
}
