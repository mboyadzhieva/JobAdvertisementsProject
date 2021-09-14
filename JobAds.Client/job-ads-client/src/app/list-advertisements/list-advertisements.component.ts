import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Advertisement } from '../models/Advertisement';
import { AdvertisementService } from '../services/advertisement.service';

@Component({
  selector: 'app-list-advertisements',
  templateUrl: './list-advertisements.component.html',
  styleUrls: ['./list-advertisements.component.css'],
})
export class ListAdvertisementsComponent implements OnInit {
  advertisements: Array<Advertisement>;

  constructor(
    private adService: AdvertisementService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getAdvertisements();
  }

  routeToDetails(id) {
    return this.router.navigate(['advertisements', id]);
  }

  deleteAdvertisement(id) {
    this.adService.deleteAdvertisement(id).subscribe((response) => {
      this.getAdvertisements();
    });
  }

  editAdvertisement(id) {
    this.router.navigate(['advertisements', id, 'edit']);
  }

  getAdvertisements() {
    this.adService.getAdvertisements().subscribe((ads) => {
      this.advertisements = ads;
    });
  }
}
