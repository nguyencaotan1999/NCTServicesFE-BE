import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./components/header/header.component";
import { FooterComponent } from "./components/footer/footer.component";
import { HomeComponent } from "./components/home/home.component";
import { ProductsComponent } from './components/products/products.component';
import { NewsComponent } from './components/news/news.component';
import { ContactComponent } from './components/contact/contact.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { CartComponent } from './components/cart/cart.component';
import { AboutComponent } from './components/about/about.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './components/admin/admin.component';
import { DataServices } from './components/Common/Common.component';
import { CommonModule } from '@angular/common';
import { OnInit  } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { filter, map } from 'rxjs/operators';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [CommonModule,RouterOutlet, HeaderComponent, FooterComponent,AdminComponent, HomeComponent,ProductsComponent,NewsComponent,ContactComponent,CheckoutComponent,CartComponent,AboutComponent,FormsModule,ReactiveFormsModule,DataServices]
})
  
export class AppComponent implements OnInit {
  showLayout = true;
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd),
        map(() => this.activatedRoute.root)
      )
      .subscribe(route => {
        while (route.firstChild) {
          route = route.firstChild;
        }
        this.showLayout = route.snapshot.data['showLayout'] !== false;
      });
  }
  title = 'Duy Trường Paint';
}