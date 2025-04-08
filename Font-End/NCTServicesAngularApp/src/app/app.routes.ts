import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { NewsComponent } from './components/news/news.component';
import { ContactComponent } from './components/contact/contact.component';
import { ProductsComponent } from './components/products/products.component';
import { CartComponent } from './components/cart/cart.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { AdminComponent } from './components/admin/admin.component';


export const routes: Routes = [
    { path: '' , component: HomeComponent, data: { showLayout: true }},
    { path: 'about', component: AboutComponent, data: { showLayout: true }},
    { path: 'news', component: NewsComponent, data: { showLayout: true }},
    { path: 'contact', component: ContactComponent, data: { showLayout: true }},
    { path: 'products',component: ProductsComponent, data: { showLayout: true }},
    { path: 'cart', component: CartComponent, data: { showLayout: true }},
    { path: 'errorpage', component: ErrorPageComponent , data: { showLayout: false }},
    { path: 'checkout', component: CheckoutComponent, data: { showLayout: true } },
    { path: 'admin', component: AdminComponent , data: { showLayout: false }},
];