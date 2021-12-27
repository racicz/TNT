import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Validation from 'src/app/helper/validation.helper';




@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {
  public form: FormGroup = Object.create(null);
  _hide = true;
  _rehide = true;
  _loading = false;

  constructor(private _fb: FormBuilder
              ) { }

  ngOnInit(): void {
    this.onInitInitialize();
  }

  onInitInitialize(){
    this.form = this._fb.group({
      name: [null, Validators.compose([Validators.required, Validators.email])],
      password:  [null, Validators.compose([Validators.required])],
      rePassword:  [null, Validators.compose([Validators.required])],
      firstName: [null, Validators.compose([Validators.required])],
      lastName: [null, Validators.compose([Validators.required])],
    },
    {
      validators: [Validation.match('password', 'rePassword')]
    });

  }

}
