import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Advertisement } from '../models/Advertisement';
import { AdvertisementService } from '../services/advertisement.service';

@Component({
  selector: 'app-edit-advertisement',
  templateUrl: './edit-advertisement.component.html',
  styleUrls: ['./edit-advertisement.component.css'],
})
export class EditAdvertisementComponent implements OnInit {
  editAdForm: FormGroup;
  advertisementId: number;
  advertisement: Advertisement;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private adService: AdvertisementService
  ) {
    this.loadForm('', '');
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.advertisementId = params['id'];
      this.adService
        .getAdvertisementById(this.advertisementId)
        .subscribe((response) => {
          this.advertisement = response;
          this.loadForm(this.advertisement.id, this.advertisement.description);
        });
    });
  }

  updateAdvertisement() {
    this.adService.editAdvertisement(this.editAdForm.value).subscribe(() => {
      this.router.navigate(['advertisements', this.advertisement.id]);
    });
  }

  private loadForm(id: string, description: string): void {
    this.editAdForm = this.fb.group({
      id: [id],
      description: [description],
    });
  }
}
