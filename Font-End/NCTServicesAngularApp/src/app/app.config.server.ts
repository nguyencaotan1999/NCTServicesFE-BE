import { mergeApplicationConfig, ApplicationConfig } from '@angular/core';
import { provideServerRendering } from '@angular/platform-server';
import { appConfig } from './app.config';
import { provideHttpClient } from '@angular/common/http';
import { provideToastr } from 'ngx-toastr';
import { CookieService } from 'ngx-cookie-service';
import { CartServiceService } from './services/cartcounter/cart-service.service';


const serverConfig: ApplicationConfig = {

  providers: [
    provideServerRendering(),
    provideHttpClient(),
    provideToastr(),
    CookieService,CartServiceService
  ]
};

export const config = mergeApplicationConfig(appConfig, serverConfig);
