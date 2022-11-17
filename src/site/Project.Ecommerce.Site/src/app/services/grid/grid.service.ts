import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { tap } from "rxjs";
import { EcommerceModel } from "src/app/Models/ecommerce.model";
import { environment } from "src/environments/environment";


@Injectable({
  providedIn: 'root'
})
export class GridService {

  constructor(private http : HttpClient) {
   }

  getAllProducts() {
      return this.http.get<EcommerceModel[]>(`/${ environment.api }`)
      .pipe(
        tap(products => console.log(products))
      );
  }
}
