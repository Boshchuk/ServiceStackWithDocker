import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.component.html',
  styles: []
})
export class CountriesListComponent implements OnInit {

  public gridData: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<Country[]>('/countries').subscribe(r => {
      this.gridData = r;
      console.log(r);
    });
  }
}
