import { Component, OnInit,ChangeDetectorRef, viewChild  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { DataServices } from '../Common/Common.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule,HttpClientModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
  
  
export class ProductsComponent implements OnInit {
  products: any[] = [];
  cartItems: any[] = [];
  loading: boolean = false;
  currentPage: number = 1;
  totalPages: number = 5;
  pageArray: number[] = [];

  constructor(private dataServices: DataServices, private cdr: ChangeDetectorRef) {
    this.reload();
   }
  
  ngOnInit(): void {
    this.GetProducts(0);
  }
  
  reload() { 
    this.pageArray = new Array(this.totalPages).fill(0).map((x, i) => i + 1);
  }
  isCurrentPage(page: number): boolean {
    return page === this.currentPage;
  }
  

  goToPage(page: number): void { 
    if (page === -1 && this.currentPage > 1) {
      this.currentPage--;
    } else if (page === 1 && this.currentPage <= this.totalPages) {
      this.currentPage++;
    }
    if (this.currentPage > this.totalPages) { 
      this.totalPages++;
      this.reload();
    }
    this.renderProducts(this.currentPage);
  }

  AddToCart(product: any) { 
    this.cartItems.push(product);
    console.log("Sản Phẩm:", this.cartItems);
    this.cartItems = [];
  }
  renderProducts(value: number) { 
    let skipProduct = 0;
    if (value != 0) {
      skipProduct = (value-1) * 8;
    } 
    this.GetProducts(skipProduct);
  }

  GetProducts(value: number) { 

    this.loading = true;
    const apiUrl = 'https://localhost:7071/api/v1/Product?skip=' + value;

    this.dataServices.getData(`${apiUrl}`).subscribe(
        (data: any[]) => {
          this.products = data;
          console.log("data", this.products);
          this.cdr.detectChanges(); 
          this.loading = false;
        },
        (error) => {
          this.loading = false;
      }
      );
    // this.http.get<any[]>(apiUrl, httpOptions).subscribe(
    //   (data: any[]) => {
    //     this.products = data;
    //     console.log("data", this.products);
    //     this.cdr.detectChanges(); 
    //     this.loading = false;
    //   },
    //   (error) => {
    //     this.loading = false;
    // }
    // );
  }
  
}
