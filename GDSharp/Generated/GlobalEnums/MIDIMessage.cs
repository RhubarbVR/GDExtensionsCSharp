namespace GDSharp {
public enum MIDIMessage : long {
	MidiMessageNone = 0,
	MidiMessageNoteOff = 8,
	MidiMessageNoteOn = 9,
	MidiMessageAftertouch = 10,
	MidiMessageControlChange = 11,
	MidiMessageProgramChange = 12,
	MidiMessageChannelPressure = 13,
	MidiMessagePitchBend = 14,
	MidiMessageSystemExclusive = 240,
	MidiMessageQuarterFrame = 241,
	MidiMessageSongPositionPointer = 242,
	MidiMessageSongSelect = 243,
	MidiMessageTuneRequest = 246,
	MidiMessageTimingClock = 248,
	MidiMessageStart = 250,
	MidiMessageContinue = 251,
	MidiMessageStop = 252,
	MidiMessageActiveSensing = 254,
	MidiMessageSystemReset = 255,
}
}
