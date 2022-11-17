import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  displayedColumns = ['Nome do Produto', 'Preço', 'Preço Promoção', 'Visível', 'Ações'];

  constructor() { }

  ngOnInit(): void {
  }

}
