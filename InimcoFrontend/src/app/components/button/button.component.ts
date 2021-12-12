import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() label: string;
  @Input() type: string;

  /* styling */
  @Input() marginTop: string;

  @Output() onClick = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onClickBtn(){
    this.onClick.emit();
  }
}
