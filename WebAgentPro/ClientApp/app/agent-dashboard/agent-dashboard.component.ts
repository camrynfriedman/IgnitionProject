import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '@environments/environment';
import { Quote } from '@app/_models/quote';

@Component({
  selector: 'app-agent-dashboard',
  templateUrl: './agent-dashboard.component.html',
  styleUrls: ['./agent-dashboard.component.css']
})
export class AgentDashboardComponent implements OnInit {
    apiUrl: string = environment.apiUrl;

    constructor(
        private route: ActivatedRoute,
        private http: HttpClient,
        private router: Router) { }

  ngOnInit(): void {
  }

}
