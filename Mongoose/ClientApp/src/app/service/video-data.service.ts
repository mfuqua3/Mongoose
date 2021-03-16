import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ISeries} from '../contracts/Series';
import {environment} from '../../environments/environment';
import {apiRoutes} from '../utilities/apiRoutes';
import {IFileInfo} from '../contracts/FileInfo';
import {ISeason} from '../contracts/Season';
import {IEpisode} from '../contracts/Episode';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VideoDataService {

  constructor(private http: HttpClient) { }

  getAllSeries(): Observable<ISeries[]> {
    const url = `${environment.apiEndpoint}${apiRoutes.series}`;
    const headers = new HttpHeaders()
      .set('Content-type', 'application/json');
    return this.http.get<ISeries[]>(url, { responseType: 'json'});
  }

  getSeasons(seriesId: number): Observable<ISeason[]> {
    const url = `${environment.apiEndpoint}${apiRoutes.seasons}/${seriesId}`;
    const headers = new HttpHeaders()
      .set('Content-type', 'application/json');
    return this.http.get<ISeason[]>(url, { responseType: 'json'});
  }

  getEpisodes(seasonId: number): Observable<IEpisode[]> {
    const url = `${environment.apiEndpoint}${apiRoutes.episodes}/${seasonId}`;
    const headers = new HttpHeaders()
      .set('Content-type', 'application/json');
    return this.http.get<IEpisode[]>(url, { responseType: 'json'});
  }

  postEpisode(episode: IEpisode): Observable<IEpisode> {
    const url = `${environment.apiEndpoint}${apiRoutes.episodes}`;
    return this.http.post<IEpisode>(url, episode, {responseType: 'json'});
  }
}
