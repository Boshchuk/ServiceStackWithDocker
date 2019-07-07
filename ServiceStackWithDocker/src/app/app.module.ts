import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { GridModule } from '@progress/kendo-angular-grid';


import { AppComponent } from './app.component';
import { HomeComponent } from './home/home';
import { View1Component } from './view1/view1';
import { View2Component } from './view2/view2';

import { JsonServiceClient } from '@servicestack/client';
import { CountriesListComponent } from './countries-list/countries-list.component';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



export const routes: Routes = [
  {
      path: '',
      redirectTo: '/',
      pathMatch: 'full'
  },
  { path: '', component: HomeComponent, data: { title: 'Home', name: 'Angular 7' } },
  { path: 'view1', component: View1Component },
  { path: 'view2', component: View2Component },
  { path: 'countries-list', component: CountriesListComponent },
  { path: '**', redirectTo: '/' },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    View1Component,
    View2Component,
    CountriesListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    InputsModule,
    BrowserAnimationsModule,
    GridModule
  ],
  providers: [{provide: JsonServiceClient, useValue: new JsonServiceClient('/')}],
  bootstrap: [AppComponent]
})
export class AppModule { }
