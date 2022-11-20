import { Component, OnInit } from '@angular/core';
import { EcommerceModel } from '../Models/ecommerce.model';
import { GridService } from '../services/grid/grid.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  dataSource: EcommerceModel[] = [];
  displayedColumns = ['Nome do Produto']

  constructor
  (
    private gridService: GridService
  ) 
  { 
  }

  ngOnInit(): void {
    this.visualizeInformation();
  }

  visualizeInformation(){
    this.gridService.getAllProducts().subscribe((element : EcommerceModel[]) => {
      this.dataSource = Object.values(element)
      this.dataSource[0]
      console.log(this.dataSource[0])
    })
  }

  deleteProduct(element: EcommerceModel) {
    this.gridService.deleteProduct(element).subscribe(() => {
      this.visualizeInformation();
    });
  }

  editProduct(element: EcommerceModel[]) {
    this.dataSource = { ...element};
  }
}
