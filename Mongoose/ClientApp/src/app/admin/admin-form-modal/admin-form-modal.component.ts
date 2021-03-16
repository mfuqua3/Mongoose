import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {IFileInfo} from '../../contracts/FileInfo';
import {VideoDataService} from '../../service/video-data.service';
import {IEpisode} from '../../contracts/Episode';
import {ISeries} from '../../contracts/Series';
import {ISeason} from '../../contracts/Season';

@Component({
  selector: 'app-admin-form-modal',
  templateUrl: './admin-form-modal.component.html',
  styleUrls: ['./admin-form-modal.component.css']
})
export class AdminFormModalComponent implements OnInit {

  @Input() file: IFileInfo;
  model: IEpisode = {
    id: 0,
    seasonId: 0,
    episodeNumber: 0,
    videoInfo: {
      name: '',
      description: '',
      filePath: ''
    }
  };
  series: ISeries[];
  selectedSeries: ISeries;
  seasons: ISeason[];

  constructor(public activeModal: NgbActiveModal, private videoDataService: VideoDataService) {
  }

  closeModal() {
    this.activeModal.close('Modal Closed');
  }

  onSeriesSelected() {
    if (this.selectedSeries == null) {
      return;
    }
    const id = this.selectedSeries.id;
    this.videoDataService.getSeasons(id).subscribe((resp) => {
      this.seasons = resp;
    });

  }

  onSubmit() {
    this.model.videoInfo.filePath = this.file.path;
    console.log(`Posting ${JSON.stringify(this.model)}`);
    this.videoDataService.postEpisode(this.model)
      .subscribe((resp) => {
        console.log(resp);
        this.closeModal();
      }, error => console.log(error));
  }

  ngOnInit(): void {
    this.videoDataService.getAllSeries().subscribe((resp) => this.series = resp);
  }
}


