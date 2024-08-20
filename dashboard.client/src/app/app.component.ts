import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  items: MenuItem[] = [];

  constructor(private readonly router: Router) { }

  ngOnInit() {
    this.items = [
      {
        label: 'Creator',
        icon: 'fa-solid fa-gear',
        routerLink: '/creator'
      },
      {
        label: 'Calculations',
        icon: 'fa-solid fa-calculator',
        routerLink: '/calculations'
      },

    ];
  }
}
