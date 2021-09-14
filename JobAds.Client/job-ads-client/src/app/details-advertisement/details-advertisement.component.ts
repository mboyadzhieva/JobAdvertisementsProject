import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Advertisement } from '../models/Advertisement';
import { AdvertisementService } from '../services/advertisement.service';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-details-advertisement',
  templateUrl: './details-advertisement.component.html',
  styleUrls: ['./details-advertisement.component.css'],
})
export class DetailsAdvertisementComponent implements OnInit {
  id;
  advertisement: Advertisement;

  constructor(
    private route: ActivatedRoute,
    private adService: AdvertisementService
  ) {
    // this.route.params.subscribe((result) => {
    //   this.id = result['id'];
    //   this.adService.getAdvertisementById(this.id).subscribe((response) => {
    //     this.advertisement = response;
    //   });
    // });

    this.fetchData();
  }

  fetchData() {
    this.route.params
      .pipe(
        map((params) => {
          const id = params['id'];
          return id;
        }),
        mergeMap((id) => this.adService.getAdvertisementById(id))
      )
      .subscribe((result) => {
        this.advertisement = result;
      });
  }

  ngOnInit(): void {}
}
