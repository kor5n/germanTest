from kivy.app import App
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.screenmanager import ScreenManager, Screen
from random import randint
test = {"die":["Haupstadt", "Schule", "Besserung", "Klasse", "Schülerin", "Musik", "Handynummer", "Schwester", "Freundin", "Woche", "Gitarre", "Straße", "Tage"],
       "das": ["Mädchen", "Zimmer", "Musikzimmer", "Handy", "Program", "Auto"],
       "der":["Schüler", "Freund", "Bruder", "Vater", "Spieler", "Stuhl", "Film"]
}
answer = str()
class quest_scr(Screen):
    def __init__(self,name="question", questions=test):
        super().__init__(name=name)
        self.main_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.upper_box = BoxLayout(orientation="vertical", padding=8, spacing=8)
        self.down_box = BoxLayout(padding=8, spacing=8)
        self.das_ans = Button(text="Das",font_size="30sp")
        self.die_ans = Button(text="Die", font_size="30sp")
        self.der_ans = Button(text="Der", font_size="30sp")
        self.next_word = Button(text="Nästa ord", font_size="20sp", background_color="blue")
        self.question_label = Label(text = "question", font_size="40sp")
        self.questions = questions
 
        self.down_box.add_widget(self.die_ans)
        self.down_box.add_widget(self.das_ans)
        self.down_box.add_widget(self.der_ans)
        self.upper_box.add_widget(self.question_label)
        self.upper_box.add_widget(self.next_word)
 
        self.main_box.add_widget(self.upper_box)
        self.main_box.add_widget(self.down_box)
 
        self.next_word.on_press = self.create_word

        self.add_widget(self.main_box)
    def on_pre_enter(self, *args):
        self.create_word()
        return super().on_pre_enter(*args)
    def create_word(self):
        global answer
        self.das_ans.background_color = "white"
        self.die_ans.background_color = "white"
        self.der_ans.background_color = "white"
        nominativ = randint(1, 3)
        if nominativ == 1:
            answer = "der"
            self.question_label.text = self.questions["der"][randint(0, len(self.questions["der"]) - 1)]
            self.der_ans.on_press = self.correct_ans
            self.die_ans.on_press = self.wrong_ans_die
            self.das_ans.on_press = self.wrong_ans_das
        elif nominativ == 2:
            answer = "die"
            self.question_label.text = self.questions["die"][randint(0, len(self.questions["die"]) - 1)]
            self.die_ans.on_press = self.correct_ans
            self.der_ans.on_press = self.wrong_ans_der
            self.das_ans.on_press = self.wrong_ans_das
        elif nominativ == 3:
            answer = "das"
            self.question_label.text = self.questions["das"][randint(0, len(self.questions["das"]) - 1)]
            self.das_ans.on_press = self.correct_ans
            self.der_ans.on_press = self.wrong_ans_der
            self.die_ans.on_press = self.wrong_ans_die
        self.next_word.set_disabled(True)
 
    def correct_ans(self):
        global answer
        if answer == "der":
            self.der_ans.background_color = "green"
        elif answer == "die":
            self.die_ans.background_color = "green"
        elif answer == "das":
            self.das_ans.background_color = "green"
        self.next_word.set_disabled(False)
    def wrong_ans_die(self):
        self.die_ans.background_color = "red"
    def wrong_ans_der(self):
        self.der_ans.background_color = "red"
    def wrong_ans_das(self): 
        self.das_ans.background_color = "red"       

class DeutcheTest(App):
    def build(self):
        sm = ScreenManager()
        sm.add_widget(quest_scr())
 
        return sm
 
app = DeutcheTest()
app.run()
