import {ISeason} from './Season';

export interface ISeries {
  id: number;
  name: string;
  description: string;
  iconPath: string;
  seasons: Array<ISeason>;
}
