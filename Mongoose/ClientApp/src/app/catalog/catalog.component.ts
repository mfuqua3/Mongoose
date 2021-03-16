import {Component, OnInit} from '@angular/core';
import {ISeries} from '../contracts/Series';
import {VideoDataService} from '../service/video-data.service';
import {ISeason} from '../contracts/Season';
import {IEpisode} from '../contracts/Episode';
import {ChromecastService} from '../service/chromecast.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {

  series: ISeries[];
  seasons: ISeason[];
  episodes: IEpisode[];

  constructor(private videoDataService: VideoDataService, private castService: ChromecastService) {
  }

  ngOnInit() {
    this.videoDataService.getAllSeries()
      .subscribe((resp) => this.series = resp);
  }

  loadSeasons(seriesItem: ISeries) {
    this.videoDataService.getSeasons(seriesItem.id)
      .subscribe((resp) => this.seasons = resp);
  }

  loadEpisodes(season: ISeason) {
    this.videoDataService.getEpisodes(season.id)
      .subscribe((resp) => this.episodes = resp.sort((a, b) => a.episodeNumber - b.episodeNumber));
  }

  playEpisode(episode: IEpisode) {
    this.castService.castEpisode(episode.id)
      .subscribe((resp) => console.log(resp));
  }
}
