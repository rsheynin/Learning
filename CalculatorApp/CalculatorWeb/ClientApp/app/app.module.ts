import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';



import { AppComponent } from './app.component';
import { CalculateResultService } from './services/calculate.service';
import { CalculateResultDirective } from "./result/calculate-result.directive";
import { CalculateResultComponent } from "./result/calculate-result.component";
import { CalculateResultColorComponent } from "./result/calculate-result-color.component";
import { CalculateResultNumberComponent } from "./result/calculate-result-number.component";
import { CalculateResultParityComponent } from "./result/calculate-result-parity.component";

@NgModule({
  declarations: [
      AppComponent,
      CalculateResultComponent,
      CalculateResultNumberComponent,
      CalculateResultColorComponent,
      CalculateResultParityComponent,
      CalculateResultDirective
  ],
  entryComponents: [
        CalculateResultNumberComponent,
        CalculateResultColorComponent,
        CalculateResultParityComponent
  ],
  imports: [
      BrowserModule,
      ReactiveFormsModule,
      HttpClientModule,
      FormsModule,
      HttpClientXsrfModule.withOptions({
          cookieName: 'My-Xsrf-Cookie',
          headerName: 'My-Xsrf-Header',
      })
  ],
  providers: [
      CalculateResultService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
