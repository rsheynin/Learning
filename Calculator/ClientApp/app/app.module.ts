import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CalculateResultService } from './services/calculate.service';
import { CalculateResultComponent } from './calculate-result/calculate-result.component';
//import { CalculateResultNumberComponent } from './calculate-result/number/calculate-result-number.component';
//import { CalculateResultColorComponent } from './calculate-result/color/calculate-result-color.component';
//import { CalculateResultParityComponent } from './calculate-result/parity/calculate-result-parity.component';
import { CalculateResultDirective } from './calculate-result/calculate-result.directive';


@NgModule({
  declarations: [
      AppComponent,
      CalculateResultComponent,
      //CalculateResultNumberComponent,
      //CalculateResultColorComponent,
      //CalculateResultParityComponent,
      CalculateResultDirective
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
  ],
  providers: [
        CalculateResultService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
