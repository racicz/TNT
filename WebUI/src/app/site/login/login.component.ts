import { AfterViewInit, Component, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  public form: FormGroup = Object.create(null);
  private inputToFocus: any;
  @ViewChildren('inputToFocus') set inputF(inputF: any) {
    this.inputToFocus = inputF
  }

  _hide = true;
  _loading = false;

  constructor(
    private _fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.onInitInitialize();
  }

  onInitInitialize(){
    this.form = this._fb.group({
      name: [null, Validators.compose([Validators.required, Validators.email])],
      password: [null, Validators.compose([Validators.required])],
      recaptchaReactive: new FormControl(null, Validators.required)
    });

  }

  onSubmit(){

  }
}
