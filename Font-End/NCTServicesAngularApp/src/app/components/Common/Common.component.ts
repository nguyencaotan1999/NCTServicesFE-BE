import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable,of  } from 'rxjs';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
@Component({
    selector: 'app-commmon',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './Common.component.html',
    styleUrl: './Common.component.css'
})
export class DataServices   { 

    constructor(private http: HttpClient) {}
    
     getData(apiUrl: string): Observable<any[]> {
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
          })
      };
        return this.http.get<any[]>(apiUrl, httpOptions);
  }

  
  postData(apiUrl: string, data: any): Observable<boolean> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    
    return this.http.post<any>(apiUrl, data, httpOptions).pipe(
      map(response => {
        if (response.succeeded) {
          return true;
        } else {
          return false;
        }
      }),
      catchError(error => {
        console.error('An error occurred:', error);
        return of(false); 
      })
    );
  }

  deleteData(apiUrl: string): Observable<boolean> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
    
    return this.http.delete<any>(apiUrl, httpOptions).pipe(
      map(response => {
        if (response.succeeded) {
          return true;
        } else {
          return false;
        }
      }),
      catchError(error => {
        // Xử lý lỗi nếu cần
        console.error('An error occurred:', error);
        return of(false); // Trả về false trong trường hợp lỗi
      })
    );
  }


}