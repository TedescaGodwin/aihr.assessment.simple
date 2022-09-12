import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { WebService } from 'src/app/services/web.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})



export class HeaderComponent implements OnInit {
  title: string = 'Course Library';
  showAddCourse: boolean = false;
  subscription: Subscription;

  constructor(private webService: WebService, private router: Router) {
    this.subscription = this.webService
      .onToggle()
      .subscribe((value) => (this.showAddCourse = value));
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    // Unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  toggleAddCourse() {
    this.webService.toggleAddCourse();
  }

  hasRoute(route: string) {
    return this.router.url === route;
  }

}
