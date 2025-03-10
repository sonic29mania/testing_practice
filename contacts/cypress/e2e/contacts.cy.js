describe("Contacts App", () => {
    beforeEach(() => {
      // Visit the app before each test
      cy.visit("http://localhost:5173");
    });
  
    it("should add a new contact", () => {
      // Arrange: Fill in the form
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Олена");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("1234567890");
  
      // Act: Click the "Додати" button
      cy.get(".form-container button").contains("Додати").click();
  
      // Assert: Check the contact appears in the list
      cy.get(".contacts-list .contact-item")
        .should("have.length", 1)
        .contains("Олена - 1234567890");
    });
  
    it("should edit an existing contact", () => {
      // Arrange: Add a contact first
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Олена");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("1234567890");
      cy.get(".form-container button").contains("Додати").click();
  
      // Act: Click "Редагувати", update fields, and save
      cy.get(".contact-item button").contains("Редагувати").click();
      cy.get(".form-container input[placeholder=\"Ім'я\"]")
        .clear()
        .type("Марія");
      cy.get(".form-container input[placeholder=\"Телефон\"]")
        .clear()
        .type("0987654321");
      cy.get(".form-container button").contains("Редагувати").click();
  
      // Assert: Check the updated contact
      cy.get(".contacts-list .contact-item").contains("Марія - 0987654321");
      cy.get(".contacts-list .contact-item").should("not.contain", "Олена");
    });
  
    it("should delete a contact", () => {
      // Arrange: Add a contact
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Олена");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("1234567890");
      cy.get(".form-container button").contains("Додати").click();
  
      // Act: Delete the contact
      cy.get(".contact-item button").contains("Видалити").click();
  
      // Assert: Check the list is empty
      cy.get(".contacts-list .contact-item").should("not.exist");
    });
  
    it("should sort contacts by name", () => {
      // Arrange: Add multiple contacts
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Богдан");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("111");
      cy.get(".form-container button").contains("Додати").click();
  
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Анна");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("222");
      cy.get(".form-container button").contains("Додати").click();
  
      // Act: Sort by name
      cy.get(".buttons-container button").contains("Сортувати за іменем").click();
  
      // Assert: Check the order (Анна should be first)
      cy.get(".contacts-list .contact-item")
        .first()
        .contains("Анна - 222");
      cy.get(".contacts-list .contact-item")
        .last()
        .contains("Богдан - 111");
    });
  
    it("should sort contacts by phone", () => {
      // Arrange: Add multiple contacts
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Богдан");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("222");
      cy.get(".form-container button").contains("Додати").click();
  
      cy.get(".form-container input[placeholder=\"Ім'я\"]").type("Анна");
      cy.get(".form-container input[placeholder=\"Телефон\"]").type("111");
      cy.get(".form-container button").contains("Додати").click();
  
      // Act: Sort by phone
      cy.get(".buttons-container button")
        .contains("Сортувати за телефоном")
        .click();
  
      // Assert: Check the order (111 should be first)
      cy.get(".contacts-list .contact-item")
        .first()
        .contains("Анна - 111");
      cy.get(".contacts-list .contact-item")
        .last()
        .contains("Богдан - 222");
    });
  });