import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AdminFormModalComponent } from './admin/admin-form-modal/admin-form-modal.component';
import { CatalogComponent } from './catalog/catalog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AdminComponent,
    AdminFormModalComponent,
    CatalogComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'admin', component: AdminComponent, pathMatch: 'full' },
      { path: 'catalog', component: CatalogComponent, pathMatch: 'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    AdminFormModalComponent
  ]
})
export class AppModule { }
