import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from "rxjs";
import { EcommerceModel } from "src/app/Models/ecommerce.model";
import { environment } from "src/environments/environment";


@Injectable({
  providedIn: 'root'
})
export class GridService {

  constructor(private http : HttpClient) {
   }

  getAllProducts() : Observable<EcommerceModel[]> {
      return this.http.get<EcommerceModel[]>(`${environment.endpoint}`)
      .pipe(
        retry(2),
        catchError(this.handleError)
        )
  }

  deleteProduct(element: EcommerceModel) {
    return this.http.delete<EcommerceModel>(`${environment.endpoint}` + '/' + element.id )
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
