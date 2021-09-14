import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdvertisementService } from '../services/advertisement.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './create-advertisement.component.html',
  styleUrls: ['./create-advertisement.component.css'],
})
export class CreateAdvertisementComponent {
  adForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private adService: AdvertisementService,
    private toastrService: ToastrService,
    private router: Router
  ) {
    this.adForm = this.fb.group({
      description: ['', [Validators.required]],
      imageUrl: ['', [Validators.required]],
    });
  }

  create(): void {
    this.adService.create(this.adForm.value).subscribe((response) => {
      this.toastrService.success('Advertisement added successfully');
      this.router.navigate(['advertisements']);
    });
  }

  get description() {
    return this.adForm.get('description');
  }

  get imageUrl() {
    return this.adForm.get('imageUrl');
  }
}
