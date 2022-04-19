import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup, FormControl } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FeedbackService } from 'src/services/feedback.service';
import { feedback } from 'src/services/feedback';


@Inject(FeedbackService)
@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent {

  feedbackForm = this.formBuilder.group({
    id: [''],
    fname: [''],
    lname: [''],
    email: [''],
    suggestions: ['']

  });

  feedback!: feedback;

  constructor(
    private formBuilder: FormBuilder,
    private FeedbackService: FeedbackService,
   ) { }


  onSubmit(data:any) {
    this.FeedbackService.submitUser(data).subscribe(result=>{});
    alert('!!Feedback Submitted Successfully!!');
 }

}
