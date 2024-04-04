import { Component, OnDestroy, OnInit } from '@angular/core';
import { Game } from './gameLogic/game';
import { AppService } from '../service/app.service';
import { timeInterval } from 'rxjs';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit, OnDestroy{

  game : Game | null = null;
  scoreSent : boolean = false;

  constructor(public service : AppService){}

  ngOnDestroy(): void {
    // Ceci est crotté mais ne le retirez pas sinon le jeu bug.
    location.reload();
  }

  ngOnInit() {
    this.game = new Game();
  }

  replay(){
    if(this.game == null) return;
    this.game.prepareGame();
    this.scoreSent = false;
  }

  sendScore(){
    if(this.scoreSent) return;

    this.scoreSent = true;
    
    // ██ Appeler une requête pour envoyer le score du joueur ██
    // Le score est dans sessionStorage.getItem("score")
    // Le temps est dans sessionStorage.getItem("time")
    // La date sera choisie par le serveur
    let score = sessionStorage.getItem("score");
    let temps = sessionStorage.getItem("time");
    if(score == null || temps == null) return;
    this.service.postScore(score, temps);


  }

}
