import { TestBed } from '@angular/core/testing';

import { ChromecastService } from './chromecast.service';

describe('ChromecastService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ChromecastService = TestBed.get(ChromecastService);
    expect(service).toBeTruthy();
  });
});
