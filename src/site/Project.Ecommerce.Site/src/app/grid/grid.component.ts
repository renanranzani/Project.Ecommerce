import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { EcommerceModel } from '../Models/ecommerce.model';
import { GridService } from '../services/grid/grid.service';


@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {

  products:Observable<EcommerceModel[]>;

  constructor(private gridService: GridService) 
  {
    this.products = this.gridService.getAllProducts();
  }

  ngOnInit(): void {
  }
  
}
