import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {IFileInfo} from '../contracts/FileInfo';
import {environment} from '../../environments/environment';
import {apiRoutes} from '../utilities/apiRoutes';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  getUnmappedFiles(): Observable<IFileInfo[]> {
    const url = `${environment.apiEndpoint}${apiRoutes.unmappedFiles}`;
    const headers = new HttpHeaders()
      .set('Content-type', 'application/json');
    return this.http.get<IFileInfo[]>(url, { responseType: 'json'});
  }
}
