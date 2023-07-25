### notes 
- when you start running an angular app, it starts in `main.ts` which uses a Bootstrap application from `@angular/platform-browser`
- in the component of `app.component.ts`:
	- the app-root selector points to `index.html`
	- aside from variables, the HTML files the component is linked to can also contained JavaScript code within the curly brackets
- angular version 2-15 required the use of an Angular Module
- to create a component in an Angular using the CLI `ng g c <directory>/<filename.ts>
- to import a list or method -
	- use ngFor="let __ of array_name" and include array items in curly brackets
	- example
	```html
	<ul>
		<li *ngFor="let friend of friends">{{friend}}
		<button (click)="unfriend(friend)">Unfriend</button>
		</li>
	</ul>
```

==Component hierarchy==- app > header & content > sections, paragraphs, sub-headers, etc.
passing information from one component to a sibling
Me and Joey must create the component that will show the list
Cypress- common testing for Angular
==Components== are the **unit of user interface**; they select the state from the global store (for states) and describe what happened as an Action and tell the store about it (for interactions)
- they take some data (state) and make it "pretty"
- accurately project the state to the user
- offers affordances the user to interact with the application (via forms, buttons, etc.)