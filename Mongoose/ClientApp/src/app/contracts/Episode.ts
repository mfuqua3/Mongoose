import {IVideoInfo} from './VideoInfo';

export interface IEpisode {
  id: number;
  seasonId: number;
  episodeNumber: number;
  videoInfo: IVideoInfo;
}
