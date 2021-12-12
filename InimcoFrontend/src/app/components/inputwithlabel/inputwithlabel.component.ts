import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-inputwithlabel',
  templateUrl: './inputwithlabel.component.html',
  styleUrls: ['./inputwithlabel.component.scss']
})
export class ImputWithLabelComponent implements OnInit {

  @Input() label: string;
  @Input() formGroupValue: FormGroup;
  @Input() formGroupName: number;
  @Input() formControlNameValue: string;
  @Input() formArrayNameValue: string;
  @Input() item: AbstractControl;

  constructor() { }

  ngOnInit(): void {
  }

}
