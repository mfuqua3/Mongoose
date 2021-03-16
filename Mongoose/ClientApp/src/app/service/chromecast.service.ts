import {Injectable} from '@angular/core';
import {ICastReceiver} from '../contracts/CastReceiver';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {apiRoutes} from '../utilities/apiRoutes';

@Injectable({
  providedIn: 'root'
})
export class ChromecastService {

  activeReceiver: ICastReceiver;

  constructor(private http: HttpClient) {
  }

  getDevices(): Observable<ICastReceiver[]> {
    const url = `${environment.apiEndpoint}${apiRoutes.devices}`;
    return this.http.get<ICastReceiver[]>(url, {responseType: 'json'});
  }

  castEpisode(episodeId: number) {
    const url = `${environment.apiEndpoint}${apiRoutes.connect}/${this.activeReceiver.id}?episodeId=${episodeId}`;
    return this.http.get(url, {responseType: 'json'});
  }

  setActiveReceiver(receiver: ICastReceiver) {
    this.activeReceiver = receiver;
  }
}
