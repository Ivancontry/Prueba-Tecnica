import { EventEmitter, Input, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {
  @Input() length: number;
  @Input() pageSize: number;
  @Input() color: string;
  @Output('page') eventPage: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }
  emitPageIndex = (page) =>this.eventPage.emit(page.pageIndex + 1)
}
