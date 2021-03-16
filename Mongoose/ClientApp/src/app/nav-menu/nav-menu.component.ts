import {Component, OnDestroy, OnInit} from '@angular/core';
import {ChromecastService} from '../service/chromecast.service';
import {interval, Subscription} from 'rxjs';
import {startWith, switchMap} from 'rxjs/operators';
import {ICastReceiver} from '../contracts/CastReceiver';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
  isExpanded = false;

  timeInterval: Subscription;
  receivers: ICastReceiver[];

  collapse() {
    this.isExpanded = false;
  }

  constructor(private castService: ChromecastService) {
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit(): void {
    this.timeInterval = interval(5000)
      .pipe(
        startWith(0),
        switchMap(() => this.castService.getDevices())
      ).subscribe((resp) => this.receivers = resp);
  }

  ngOnDestroy(): void {
    this.timeInterval.unsubscribe();
  }

  selectReceiver(receiver: ICastReceiver) {
    this.castService.activeReceiver = receiver;
  }
}
