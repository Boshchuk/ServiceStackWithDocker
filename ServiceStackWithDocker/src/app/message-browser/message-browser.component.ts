import { Component, OnInit } from '@angular/core';
import { GridDataResult, PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { HttpClient, HttpParams } from '@angular/common/http';
import { DataSourceRequestState, DataResult } from '@progress/kendo-data-query';

@Component({
  selector: 'app-message-browser',
  templateUrl: './message-browser.component.html',
  styleUrls: ['./message-browser.component.css']
})
export class MessageBrowserComponent implements OnInit {

  public gridView: GridDataResult;
  public pageSize = 10;
  
  private data: any;

  public state: DataSourceRequestState = {
    skip: 0,
    take: 3
  };

  constructor(private http: HttpClient) {
    this.loadItems();
  }

  ngOnInit() {
  }

  public dataStateChange(state: DataStateChangeEvent): void {
    this.state = state;
    this.loadItems();
  }

  private loadItems(): void {
    let params = new HttpParams();
    params = params.append("skip", String(this.state.skip));
    params = params.append("take", String(this.state.take));
    console.log(params);
    this.http.get<SentSmsResponse>('/sms/sent',{ params: params }).subscribe(r => {
      this.gridView = {
        data: r.items,
        total: r.totalCoint
        }
    });
  }
}
