import {IEpisode} from './Episode';

export interface ISeason {
  id: number;
  name: string;
  description: string;
  seriesId: number;
  seasonNumber: number;
  iconPath: string;
  episodes: Array<IEpisode>;
}
