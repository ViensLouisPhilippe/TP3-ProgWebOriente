import { Component, OnInit } from '@angular/core';
import { Score } from '../models/score';
import { AppService } from '../service/app.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {

  myScores : Score[] = [];
  publicScores : Score[] = [];
  userIsConnected : boolean = false;

  constructor(public service : AppService) { }

  async ngOnInit() {

    this.userIsConnected = sessionStorage.getItem("token") != null;
    if(this.userIsConnected)
    {
      this.myScores = await this.service.getMyScore();
    }
    this.publicScores = await this.service.getScores();
  }

  async changeScoreVisibility(score : Score){


  }

}
