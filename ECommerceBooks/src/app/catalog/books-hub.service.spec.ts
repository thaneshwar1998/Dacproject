import { TestBed } from '@angular/core/testing';

import { BooksHubService } from './books-hub.service';

describe('BooksHubService', () => {
  let service: BooksHubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BooksHubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
