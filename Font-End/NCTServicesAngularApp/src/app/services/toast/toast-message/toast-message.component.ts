import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-toast-message',
  standalone: true,
  imports: [],
  templateUrl: './toast-message.component.html',
  styleUrl: './toast-message.component.css'
})
export class ToastMessageComponent {
  constructor(private toastr: ToastrService) {

  }
  
  showSuccess(message:any) { 
    this.toastr.success(message);
  }
  showError(message:any) { 
    this.toastr.error(message);
  }
}
