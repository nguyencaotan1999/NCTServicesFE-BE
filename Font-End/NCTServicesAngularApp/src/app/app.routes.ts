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
    { path: '' , component: HomeComponent},
    { path: 'about', component: AboutComponent},
    { path: 'news', component: NewsComponent},
    { path: 'contact', component: ContactComponent},
    { path: 'products',component: ProductsComponent},
    { path: 'cart', component: CartComponent},
    { path: 'errorpage', component: ErrorPageComponent },
    { path: 'checkout', component: CheckoutComponent },
    { path: 'admin', component: AdminComponent },
];